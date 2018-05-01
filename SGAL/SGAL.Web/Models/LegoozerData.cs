using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGAL.Web.Models
{
    public class LegooZerData
    {
        private static List<LegooZer> _legoozers = null;

        public static List<LegooZer> OberLegoozers()
        {
            if (_legoozers == null)
            {
                _legoozers = new List<LegooZer>()
                {
                    new LegooZer(1) { Nome = "Mad", SobreNome = "Max", EnderecoEmail = "mad@max.com.br" },
                    new LegooZer(2) { Nome = "Harry", SobreNome = "Potter", EnderecoEmail = "harry@potter.com.br" },
                    new LegooZer(3) { Nome = "R2", SobreNome = "D2", EnderecoEmail = "r2@d2.com.br" },
                    new LegooZer(4) { Nome = "James", SobreNome = "Bond", EnderecoEmail = "james@bond.com.br" },
                    new LegooZer(5) { Nome = "C3", SobreNome = "PO", EnderecoEmail = "c3@po.com.br" },
                    new LegooZer(6) { Nome = "Hans", SobreNome = "Solo", EnderecoEmail = "hans@solo.com.br" },
                    new LegooZer(7) { Nome = "Luke", SobreNome = "SkyWalker", EnderecoEmail = "luke@skywalker.com.br" },
                    new LegooZer(8) { Nome = "James", SobreNome = "Kirk", EnderecoEmail = "james@kirk.com.br" },
                    new LegooZer(9) { Nome = "Clark", SobreNome = "Kent", EnderecoEmail = "clark@kent.com.br" },
                    new LegooZer(10) { Nome = "Bruce", SobreNome = "Waine", EnderecoEmail = "bruce@waine.com.br" },
                };
            }

            return _legoozers;
        }
    }
}