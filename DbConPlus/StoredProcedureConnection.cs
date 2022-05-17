using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DbConPlus
{
    public class StoredProcedureConnection : Connection 
    {
        private string name;
        private List<Parameter> parameters = new List<Parameter>();
        public StoredProcedureConnection(string connectionString, string aName, List<Parameter> aParameters) 
            : base(connectionString)
        {
            name = aName;
            foreach (Parameter parameter in aParameters)
                parameters.Add(parameter);
        }

        public List<object> ExecuteStoredProcedure()
        {
            List<OutputParamater> outputParams = new List<OutputParamater>();
            using (SqlConnection con = new SqlConnection(base.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Parameter param in parameters)
                {
                    if (param.GetType() == typeof(InputParameter))
                    {
                        InputParameter inputParam = (InputParameter)param;
                        cmd.Parameters.Add(inputParam.Name, inputParam.Type).Value = inputParam.Value;
                    }
                    else if (param.GetType() == typeof(OutputParamater))
                    {
                        OutputParamater outputParam = (OutputParamater)param;
                        if (outputParam.Type == SqlDbType.VarChar)
                        {
                            if (outputParam.Size != null)
                                cmd.Parameters.Add(outputParam.Name, outputParam.Type, int.Parse(outputParam.Size.ToString())).Direction = ParameterDirection.Output;
                            else
                                throw new Exception();
                        }
                        else if (outputParam.Type == SqlDbType.Decimal)
                        {
                            if (outputParam.Precision != null && outputParam.Scale != null)
                            {
                                SqlParameter decimalParam = cmd.Parameters.Add(outputParam.Name, outputParam.Type);
                                decimalParam.Direction = ParameterDirection.Output;
                                decimalParam.Precision = byte.Parse(outputParam.Precision.ToString());
                                decimalParam.Scale = byte.Parse(outputParam.Scale.ToString());
                            }
                            else
                                throw new Exception();
                        }
                        else if (outputParam.Type == SqlDbType.Int)
                        {
                            cmd.Parameters.Add(outputParam.Name, outputParam.Type).Direction = ParameterDirection.Output;
                        }
                        else
                            throw new Exception();
                        outputParams.Add(outputParam);
                    }
                }
                con.Open();
                cmd.ExecuteNonQuery();
                List<object> outputParamResults = new List<object>();
                foreach (OutputParamater outputParam in outputParams)
                    outputParamResults.Add(cmd.Parameters[outputParam.Name].Value);
                return outputParamResults;
            }
        }
    }
}
