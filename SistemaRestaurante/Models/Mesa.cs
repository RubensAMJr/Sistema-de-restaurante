﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Mesa
    {

        public int MesaId { get; set; }
        public int Numero { get; set; }
        public IList<MesaComanda> Comandas { get; set; }

    }
}