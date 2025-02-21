using ITBoostUp.BusinessLayer.IRepository;
using ITBoostUp.BusinessLayer.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBoostUp.DataAccessLayer.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public int Create(Country country)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("CreateCountry", con);
            cmd.Parameters.AddWithValue("@CountryName", country.CountryName);
            cmd.Parameters.AddWithValue("@CountryDescription", country.CountryDescription);
            cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy",country.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", country.UpdatedBy);
            cmd.Parameters.AddWithValue("@IsActive", country.IsActive ? 1 : 0 );
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public void Delete(int countryId)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteCountry", con);
            cmd.Parameters.AddWithValue("@CountryId", countryId);


            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
        }

        public Country GetElementById(int countryId)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetCountryById", con);
            cmd.Parameters.AddWithValue("@CountryId", countryId);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            var country = new Country();
            while (sqlDataReader.Read())
            {
                country.CountryId = Convert.ToInt32(sqlDataReader["CountryId"]);
                country.CountryName = Convert.ToString(sqlDataReader["CountryName"]);
                country.CountryDescription = Convert.ToString(sqlDataReader["CountryDescription"]);
                country.CreatedOn = Convert.ToDateTime(sqlDataReader["CreatedOn"]);
                country.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                country.UpdatedOn = Convert.ToDateTime(sqlDataReader["UpdateOn"]);
                country.UpdatedBy = Convert.ToInt32(sqlDataReader["UpdateBy"]);
                country.IsActive = (Convert.ToInt32(sqlDataReader["IsActive"]) == 1 ? true : false);
            }
            con.Close();
            return country;
        }
        public List<Country> List()
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetCountry", con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            var countryList = new List<Country>();
            while (sqlDataReader.Read())
            {
                Country country = new Country();
                country.CountryId = Convert.ToInt32(sqlDataReader["CountryId"]);
                country.CountryName = Convert.ToString(sqlDataReader["CountryName"]);
                country.CountryDescription = Convert.ToString(sqlDataReader["CountryDescription"]);
                country.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                countryList.Add(country);
            }
            return countryList;
        }
        public int Update(Country country)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateCountry", con);
            cmd.Parameters.AddWithValue("@CountryId", country.CountryId);
            cmd.Parameters.AddWithValue("@CountryName", country.CountryName);
            cmd.Parameters.AddWithValue("@CountryDescription", country.CountryDescription);
            cmd.Parameters.AddWithValue("@CreatedBy", country.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", country.UpdatedBy);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
