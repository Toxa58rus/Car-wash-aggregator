using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace CarUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /* private readonly IConfiguration _configuration;
         public UserController(IConfiguration configuration)
         {
             _configuration = configuration;
         }
         public JsonResult Get()
         {


             return new JsonResult(table);
         }
         [HttpPost]
         public JsonResult Post(UserInfo user)
         {
             string query = @"
                              insert into dbo.Number
                               (byte7,byte6,byte5,byte4,byte3,byte2,byte1,byte0,number)
                              values (@byte7,@byte6,@byte5,@byte4,@byte3,@byte2,@byte1,@byte0,@number)
                               ";

             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("BinaryApp");
             SqlDataReader myReader;
             using (SqlConnection myCon = new SqlConnection(sqlDataSource))
             {
                 myCon.Open();
                 using (SqlCommand myCommand = new SqlCommand(query, myCon))
                 {
                     ConvertToByte toByte = new ConvertToByte();
                     toByte.convert(dep.number);

                     myCommand.Parameters.AddWithValue("@byte7", dep.byte7 = (int)char.GetNumericValue(toByte.bite[0]));
                     myCommand.Parameters.AddWithValue("@byte6", dep.byte6 = (int)char.GetNumericValue(toByte.bite[1]));
                     myCommand.Parameters.AddWithValue("@byte5", dep.byte5 = (int)char.GetNumericValue(toByte.bite[2]));
                     myCommand.Parameters.AddWithValue("@byte4", dep.byte4 = (int)char.GetNumericValue(toByte.bite[3]));
                     myCommand.Parameters.AddWithValue("@byte3", dep.byte3 = (int)char.GetNumericValue(toByte.bite[4]));
                     myCommand.Parameters.AddWithValue("@byte2", dep.byte2 = (int)char.GetNumericValue(toByte.bite[5]));
                     myCommand.Parameters.AddWithValue("@byte1", dep.byte1 = (int)char.GetNumericValue(toByte.bite[6]));
                     myCommand.Parameters.AddWithValue("@byte0", dep.byte0 = (int)char.GetNumericValue(toByte.bite[7]));
                     myCommand.Parameters.AddWithValue("@number", dep.number);

                     myReader = myCommand.ExecuteReader();
                     table.Load(myReader);
                     myReader.Close();
                     myCon.Close();
                 }
             }

             return new JsonResult("Added Successfully");
         }

         [HttpPut]
         public JsonResult Put(Binary dep)
         {
             string query = @"
                            update dbo.Number
                            set number= @number,
                             byte7=@byte7,byte6=@byte6,byte5=@byte5,byte4=@byte4,byte3=@byte3,byte2=@byte2,byte1=@byte1,byte0=@byte0
                             where id=@id
                             ";

             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("BinaryApp");
             SqlDataReader myReader;
             using (SqlConnection myCon = new SqlConnection(sqlDataSource))
             {
                 myCon.Open();
                 using (SqlCommand myCommand = new SqlCommand(query, myCon))
                 {
                     ConvertToByte toByte = new ConvertToByte();
                     toByte.convert(dep.number);
                     myCommand.Parameters.AddWithValue("@byte7", dep.byte7 = (int)char.GetNumericValue(toByte.bite[0]));
                     myCommand.Parameters.AddWithValue("@byte6", dep.byte6 = (int)char.GetNumericValue(toByte.bite[1]));
                     myCommand.Parameters.AddWithValue("@byte5", dep.byte5 = (int)char.GetNumericValue(toByte.bite[2]));
                     myCommand.Parameters.AddWithValue("@byte4", dep.byte4 = (int)char.GetNumericValue(toByte.bite[3]));
                     myCommand.Parameters.AddWithValue("@byte3", dep.byte3 = (int)char.GetNumericValue(toByte.bite[4]));
                     myCommand.Parameters.AddWithValue("@byte2", dep.byte2 = (int)char.GetNumericValue(toByte.bite[5]));
                     myCommand.Parameters.AddWithValue("@byte1", dep.byte1 = (int)char.GetNumericValue(toByte.bite[6]));
                     myCommand.Parameters.AddWithValue("@byte0", dep.byte0 = (int)char.GetNumericValue(toByte.bite[7]));
                     myCommand.Parameters.AddWithValue("@number", dep.number);
                     myCommand.Parameters.AddWithValue("@id", dep.id);
                     myReader = myCommand.ExecuteReader();
                     table.Load(myReader);
                     myReader.Close();
                     myCon.Close();
                 }
             }

             return new JsonResult("Updated Successfully");
         }

         [HttpDelete("{id}")]
         public JsonResult Delete(int id)
         {
             string query = @"
                            delete from dbo.Number
                             where id=@id
                             ";

             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("BinaryApp");
             SqlDataReader myReader;
             using (SqlConnection myCon = new SqlConnection(sqlDataSource))
             {
                 myCon.Open();
                 using (SqlCommand myCommand = new SqlCommand(query, myCon))
                 {
                     myCommand.Parameters.AddWithValue("@id", id);

                     myReader = myCommand.ExecuteReader();
                     table.Load(myReader);
                     myReader.Close();
                     myCon.Close();
                 }
             }

             return new JsonResult("Deleted Successfully");
         }
     }*/
    }
}
