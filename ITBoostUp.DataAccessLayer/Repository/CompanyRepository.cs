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
    public class CompanyRepository : ICompanyRepository
    {

        public int Create(Company company)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("CreateCompany", con);
            cmd.Parameters.AddWithValue("@CompanyName", company.Name);
            cmd.Parameters.AddWithValue("@CompanyAddress", company.Address);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public Company GetElementById(int id)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetById", con);
            cmd.Parameters.AddWithValue("@CompanyId", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            var company = new Company();
            while (sqlDataReader.Read())
            {
                company.Id = Convert.ToInt32(sqlDataReader["Id"]);
                company.Name = sqlDataReader.GetString(1);
                company.Address = sqlDataReader.GetString(2);

            }
            con.Close();
            return company;

        }

        public List<Company> List()
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetCompany", con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            var companyList = new List<Company>();
            while (sqlDataReader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(sqlDataReader["Id"]);
                company.Name = sqlDataReader.GetString(1);
                company.Address = sqlDataReader.GetString(2);
                companyList.Add(company);

            }
            return companyList;
        }
        public int Update(Company company)
        {
            string connstring = "Server=localhost;Database=ITBoostup;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateCompany", con);
            cmd.Parameters.AddWithValue("@CompanyId", company.Id);
            cmd.Parameters.AddWithValue("@CompanyName", company.Name);
            cmd.Parameters.AddWithValue("@CompanyAddress", company.Address);
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
            SqlCommand cmd = new SqlCommand("deleteCompany", con);
            cmd.Parameters.AddWithValue("@CompanyId",id);


            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
