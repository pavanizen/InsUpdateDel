using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InsUpdateDel
{
    class StPro
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public int ShowData()
        {
            try
            {
                Console.WriteLine("Data from the table after the dml command");
                Console.WriteLine("-----------------------");
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from employeetab", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["empid"]}\t \t{dr["empname"]} \t {dr["salary"]} \t {dr["deptno"]}");
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }
        public int InsertWithSp()
        {
            try
            {
                //Console.WriteLine("Enter an existing employee id to update the record... employee id");
                //var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter employee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_InsertEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd = new SqlCommand("insert into employetab values(@empname,@esal,@deptid)", cn);
               // cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = did;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int UpdateWithSp()
        {
            try
            {
                Console.WriteLine("Enter an existing employee id to update the record... employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter employee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_UpdateEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd = new SqlCommand("insert into employetab values(@empname,@esal,@deptid)", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = did;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return 1;
            }
            finally
            {

                cn.Close();
            }
        }
        public int DeleteWithSp()
        {
            try
            {
                Console.WriteLine("Enter Employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_DeleteEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int DetailsWithSp()
        {
            try
            {
                Console.WriteLine("Enter an existing employee id to update the record... employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
               
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_Details", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;
                
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        
                        Console.WriteLine($"Empname:{dr["EmpName"].ToString()}");
                        Console.WriteLine($"Salary:{dr["Salary"].ToString()}");
                        //Console.WriteLine($"DeptId: { dr["deptno"]}");
                        Console.WriteLine($"DeptName:{dr["deptname"]}");



                    }
                }
                //ShowData();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return 1;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }
    }

    class StoredProceduesInsUpDel
    {
        static void Main()
        {
             StPro spi = new StPro();

            spi.ShowData();
            Console.WriteLine("-------------------------");

            int i = 0;
            while (i == 0)
            {
                Console.WriteLine("1.Insert");
                Console.WriteLine("2.Delete");
                Console.WriteLine("3.Update");
               
                Console.WriteLine("4.Details");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Enter your choice:");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Insert one row");
                        spi.InsertWithSp();
                        break;
                    case 2:
                        Console.WriteLine("Delete one row");

                        spi.DeleteWithSp();
                        break;
                    case 3:
                        Console.WriteLine("Update one row");
                        spi.UpdateWithSp();
                        break;
                    case 4:
                        Console.WriteLine("Details");
                        spi.DetailsWithSp();
                        break;
                    case 5:
                        i = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

            }

            Console.ReadLine();

        }
    }
}
