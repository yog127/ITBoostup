using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.BusinessLayer.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBoostUp.DataAccessLayer.Repository
{
    public class StateRepository : IStateRepository
    {
        public int Create(State state)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("CreateState", con);
            cmd.Parameters.AddWithValue("@stateName", state.StateName);
            cmd.Parameters.AddWithValue("@stateDescription", state.StateDescription);
            cmd.Parameters.AddWithValue("@CountryId", state.CountryId);
            cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", state.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", state.UpdatedBy);
            cmd.Parameters.AddWithValue("@IsActive", state.IsActive ? 1 : 0);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public void Delete(int id)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteState", con);
            cmd.Parameters.AddWithValue("@StateId", id);


            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
        }

        public State GetElementById(int StateId)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetStateById", con);
            cmd.Parameters.AddWithValue("@StateId", StateId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            var state = new State();
            while (sqlDataReader.Read())
            {
                state.StateId = Convert.ToInt32(sqlDataReader["StateId"]);
                state.StateName = Convert.ToString(sqlDataReader["StateName"]);
                state.CountryId = Convert.ToInt32(sqlDataReader["CountryId"]);
                state.StateDescription = Convert.ToString(sqlDataReader["StateDescription"]);
                state.CreatedOn = Convert.ToDateTime(sqlDataReader["CreatedOn"]);
                state.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                state.UpdatedOn = Convert.ToDateTime(sqlDataReader["UpdateOn"]);
                state.UpdatedBy = Convert.ToInt32(sqlDataReader["UpdateBy"]);
                state.IsActive = (Convert.ToInt32(sqlDataReader["IsActive"]) == 1 ? true : false);
            }
            con.Close();
            return state;
        }

        public List<StateList> List()
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetState", con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            var stateList = new List<StateList>();
            while (sqlDataReader.Read())
            {
                StateList state = new StateList();
                state.StateId = Convert.ToInt32(sqlDataReader["StateId"]);
                state.StateName = Convert.ToString(sqlDataReader["StateName"]);
                state.CountryName = Convert.ToString(sqlDataReader["CountryName"]);
                state.StateDescription = Convert.ToString(sqlDataReader["StateDescription"]);
                state.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);

                stateList.Add(state);
            }
            return stateList;
        }

        public int Update(State state)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateState", con);
            cmd.Parameters.AddWithValue("@StateId", state.StateId);
            cmd.Parameters.AddWithValue("@StateName", state.StateName);
            cmd.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", state.UpdatedBy);
            cmd.Parameters.AddWithValue("@StateDescription", state.StateDescription);
            cmd.Parameters.AddWithValue("@IsActive", state.IsActive ? 1 : 0);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
