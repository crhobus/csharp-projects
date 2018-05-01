using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SGAL.Web.Controllers
{
    public class CalendarioUtilsController : Controller
    {
        public ActionResult NumeroDaSemana(int ano, int numSemana)
        {
            string[] str = ObterPrimeiroUltimoDiaSemana(ano, numSemana);

            return Content("Domingo: " + str[0] + "</br>" + "Sabado: " + str[1]);
        }

        public ActionResult NumeroDaSemanaFormato(int ano, int numSemana, string formato)
        {
            string[] str = ObterPrimeiroUltimoDiaSemana(ano, numSemana);

            switch (formato)
            {
                case "bruto":
                    return Content("Domingo: " + str[0] + "</br>" + "Sabado: " + str[1]);
                case "json":
                    return Json(new { Domingo = str[0], Sabado = str[1] }
                                , JsonRequestBehavior.AllowGet
                                );
                case "arquivo":
                    var mensagem = "Domingo: " + str[0] + "\u000d\u000a" + "Sabado: " + str[1];
                    var conteudo = Encoding.UTF8.GetBytes(mensagem);
                    return File(conteudo,"application/octet-stream", "arquivo.txt");
                default:
                    return new EmptyResult();
            }


        }

        private string[] ObterPrimeiroUltimoDiaSemana(int ano, int numSemana)
        {
            DateTime data = new DateTime(ano, 1, 1);

            data = data.AddDays(7 * (numSemana - 1));

            var dataInicioSemana = data.AddDays(1 - (int)data.DayOfWeek).AddDays(-1);

            var dataFimSemana = data.AddDays(7 - (int)data.DayOfWeek).AddDays(-1);

            string[] str = new string[2];
            str[0] = dataInicioSemana.ToString("dd/MM/yyyy");
            str[1] = dataFimSemana.ToString("dd/MM/yyyy");

            return str;
        }
    }
}