using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal3.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Portal3.Controllers
{
    public class Users1CController : Controller
    {
        PrognozEDWEntities db = new PrognozEDWEntities();
        SalesEntities db2 = new SalesEntities();

        // GET: Users1C
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowUsers(string submitButton, string searchString, string RUfirstname, string RUlastame, string ENfirstname,
            string ENlastname, string domainname, string mail, string idsprav, string id1c, string idcrm, string staffcode, string empdate, string kickdate)
        {
            switch (submitButton)
            {
                case "Map":
                    {
                        if (RUfirstname != "" && RUlastame != "" && ENfirstname != "" &&
                    ENlastname != "" && domainname != "" && mail != "")
                        {
                            try
                            {
                                #region -1 param

                                if (idsprav == "")
                                    idsprav = "-1";

                                if (id1c == "")
                                    id1c = "-1";

                                if (idcrm == "")
                                    idcrm = "-1";

                                #endregion

                                db2.MapUser(RUfirstname, RUlastame, ENfirstname, ENlastname, domainname, mail,
                                    Convert.ToInt32(idsprav), Convert.ToInt32(id1c), idcrm, staffcode, empdate, kickdate);
                            }
                            catch (Exception ex)
                            {
                                return PartialView(ex);
                            }
                        }

                        return PartialView();
                    };

                case "Search":
                    {
                        if (searchString != null)
                        {
                            CobinedUserList model = new CobinedUserList();
                            List<string> mappedlist = MapperFuncs.MapRUEN(searchString);
                            string request = ";";

                            foreach (string mappedres in mappedlist)
                                request += mappedres + ";";

                            model.list1C = db.FindUsers1C(searchString).ToList();
                            model.listCRM = db.FindUsersCRM(request).ToList();
                            model.listSpr = db2.FindSpr(searchString).ToList();

                            return PartialView(model);
                        }
                        return PartialView();
                    }
                default:
                    {
                        return PartialView();
                    }
            }
        }
        //private void MapUser(string nameru, string famru, string nameen, string famen, string domain, string mail,string id, string id1c, string idcrm, string staff, string empdate, string dismiss)
        //{
        //    SqlConnection connection = new SqlConnection("metadata=res://*/Models.SalesModel.csdl|res://*/Models.SalesModel.ssdl|res://*/Models.SalesModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=msk02drkp02;initial catalog=Sales;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");
        //    string sqlExpression = "MapUserUpd";
        //    connection.Open();

        //    SqlCommand command = new SqlCommand(sqlExpression, connection);
        //    command.CommandType = System.Data.CommandType.StoredProcedure;

        //    #region Params

        //    SqlParameter nameruParam = new SqlParameter
        //    {
        //        ParameterName = "@FirstNameRU",
        //        Value = nameru
        //    };
        //    command.Parameters.Add(nameruParam);

        //    SqlParameter famruParam = new SqlParameter
        //    {
        //        ParameterName = "@LastNameRU",
        //        Value = famru
        //    };
        //    command.Parameters.Add(famruParam);

        //    SqlParameter nameenParam = new SqlParameter
        //    {
        //        ParameterName = "@FirstNameEn",
        //        Value = nameen
        //    };
        //    command.Parameters.Add(nameenParam);

        //    SqlParameter famenParam = new SqlParameter
        //    {
        //        ParameterName = "@LastNameEn ",
        //        Value = famen
        //    };
        //    command.Parameters.Add(famenParam);

        //    SqlParameter domainParam = new SqlParameter
        //    {
        //        ParameterName = "@DomainName ",
        //        Value = domain
        //    };
        //    command.Parameters.Add(domainParam);

        //    SqlParameter mailParam = new SqlParameter
        //    {
        //        ParameterName = "@Mail",
        //        Value = mail
        //    };
        //    command.Parameters.Add(mailParam);
        //    if (id != "")
        //    {
        //        SqlParameter useridParam = new SqlParameter
        //        {
        //            ParameterName = "@userID",
        //            Value = id
        //        };
        //        command.Parameters.Add(useridParam);
        //    }
        //    else
        //    {
        //        SqlParameter useridParam = new SqlParameter
        //        {
        //            ParameterName = "@userID",
        //            Value = "-1"
        //        };
        //        command.Parameters.Add(useridParam);
        //    }
        //    if (id1c == "")
        //    {
        //        SqlParameter id1cParam = new SqlParameter
        //        {
        //            ParameterName = "@ID1C",
        //            Value = "-1"
        //        };
        //        command.Parameters.Add(id1cParam);
        //    }
        //    else
        //    {
        //        SqlParameter id1cParam = new SqlParameter
        //        {
        //            ParameterName = "@ID1C",
        //            Value = id1c
        //        };
        //        command.Parameters.Add(id1cParam);
        //    }

        //    if (idcrm == "")
        //    {
        //        SqlParameter idcrmParam = new SqlParameter
        //        {
        //            ParameterName = "@IDCRM",
        //            Value = "-1"
        //        };
        //        command.Parameters.Add(idcrmParam);
        //    }
        //    else
        //    {
        //        SqlParameter idcrmParam = new SqlParameter
        //        {
        //            ParameterName = "@IDCRM",
        //            Value = idcrm
        //        };
        //        command.Parameters.Add(idcrmParam);
        //    }
        //    SqlParameter staffParam = new SqlParameter
        //    {
        //        ParameterName = "@StaffCode",
        //        Value = staff
        //    };
        //    command.Parameters.Add(staffParam);
        //    SqlParameter empdateParam = new SqlParameter
        //    {
        //        ParameterName = "@EmpDate",
        //        Value = empdate
        //    };
        //    command.Parameters.Add(empdateParam);
        //    SqlParameter dismissParam = new SqlParameter
        //    {
        //        ParameterName = "@dismissDate",
        //        Value = dismiss
        //    };
        //    command.Parameters.Add(dismissParam);

        //    #endregion

        //    command.ExecuteNonQuery();
        //}

        // GET: Users1C/Details/5
    }
}
