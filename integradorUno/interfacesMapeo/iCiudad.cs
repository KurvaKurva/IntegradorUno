﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace interfacesMapeo
{
    public interface iCiudad
    {
        List<Ciudad> obtenerTodos();
        Ciudad obtenerPorId(int xId);
        //void guardar(Ciudad objC);
    }
}
