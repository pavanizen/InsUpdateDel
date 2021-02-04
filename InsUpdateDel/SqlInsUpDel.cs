using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InsUpdateDel
{
    class WithoutParam
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
        public int InserOneRow()
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
                cmd = new SqlCommand("insert into employeetab values('" + ename + "'," + esal + "," + did + ")", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row added to the table...");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int DeleteOnerow()
        {
            
            try
            {
                Console.WriteLine("Enter employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("delete from employeetab where empid=" + eid + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row Deleted..");
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
        public int SearchRow()
        {
            
            try
            {
                Console.WriteLine("Enter employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from employeetab where empid=" + eid + "", cn);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        // Console.WriteLine($"Empname:{dr["EmpName"].ToString()}\t Salary:{ dr["Salary"].ToString()}\t DeptId:{dr["deptid"]}");
                        Console.WriteLine($"Empname:{dr["EmpName"].ToString()}");
                        Console.WriteLine($"Salary:{dr["Salary"].ToString()}");
                        Console.WriteLine($"DeptId: { dr["deptno"]}");
                        //Console.WriteLine($"DeptName:{dr["deptname"]}");



                    }
                }

                Console.WriteLine("Search..");
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

        public int UpdateOnerow()
        {
            
            try
            {
                Console.WriteLine("Enter employee id");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter employee Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-CL2O992;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update employeetab set empname='" + ename + "',Salary=" + esal + ",deptno=" + did + " where empid=" + eid + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row Updated..");
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
    }
    class SqlInsUpDel
    {
        static void Main()
        {
            WithoutParam wp = new WithoutParam();
            wp.ShowData();
            Console.WriteLine("--------------------");
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
                        wp.InserOneRow();
                        break;
                    case 2:
                        Console.WriteLine("Delete one row");

                        wp.DeleteOnerow();
                        break;
                    case 3:
                        Console.WriteLine("Update one row");
                        wp.UpdateOnerow();
                        break;
                    case 4:
                        Console.WriteLine("Details");
                        wp.SearchRow();
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
