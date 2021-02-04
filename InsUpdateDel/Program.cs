using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InsUpdateDel
{
    class SqlRows
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public int ShowData()
        {
            try
            {
                Console.WriteLine("Data from the table");
                Console.WriteLine("-----------------------");
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from employeetab", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["empid"]}\t \t{dr["empname"]}\t \t{dr["salary"]}\t            \t{dr["deptno"]}");
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
        public int InsertWithParameters()
        {
            try
            {
                Console.WriteLine("Enter employee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into employeetab values(@ename,@esal,@deptid)", cn);
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = did;

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row added to the table...");
                ShowData();

                return 1;

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
        public int DeleteWithParameters()
        {
            try
            {
                Console.WriteLine("Enter Employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("delete from employeetab where empid=@eid",cn);
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row deleted from the table...");
                ShowData();

                return 1;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                cn.Close();
            }

        }
        public int UpdateWithParameters()
        {

            try
            {
                Console.WriteLine("Enter Employee Id");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter employee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update employeetab set empname=@ename,Salary=@esal,DeptNo=@did where empid=@eid", cn);
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row Updated to the table...");
                ShowData();

                return 1;

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
        public int SearchRow()
        {
            try
            {
                Console.WriteLine("Enter an existing employee id to update the record... employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter employee Name");
                //var ename = Console.ReadLine();
          


                //Console.WriteLine("Enter Employee Salary");
                //var esal = Convert.ToSingle(Console.ReadLine());
                //Console.WriteLine("Enter Employee dept id");
                //var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select @ename,@esal,@did from employeetab where empid=@eid", cn);
                //cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                //cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                //cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        // Console.WriteLine($"Empname:{dr["EmpName"].ToString()}\t Salary:{ dr["Salary"].ToString()}\t DeptId:{dr["deptid"]}");
                        Console.WriteLine($"Empname:{dr["EmpName"].ToString()}");
                        Console.WriteLine($"Salary:{dr["Salary"].ToString()}");
                        //Console.WriteLine($"DeptId: { dr["deptno"]}");
                        Console.WriteLine($"DeptName:{dr["deptname"]}");



                    }
                }
                ShowData();
                return 1;

            }
            catch(Exception ex)
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

    class Program
    {
        static void Main(string[] args)
        {
            SqlRows sr = new SqlRows();
            sr.ShowData();
            //sr.InsertWithParameters();
            //sr.DeleteWithParameters();
            //sr.UpdateWithParameters();
            //sr.SearchRow();

            Console.WriteLine("---------------------");
            int i = 0;
            while (i == 0)
            {
                Console.WriteLine("1.Insert");
                Console.WriteLine("2.Delete");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice:");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Insert one row");
                        sr.InsertWithParameters();
                        break;
                    case 2:
                        Console.WriteLine("Delete one row");
                        sr.DeleteWithParameters();
                        break;
                    case 3:
                        Console.WriteLine("Update one row");
                        sr.UpdateWithParameters();
                        break;
                    case 4:
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
