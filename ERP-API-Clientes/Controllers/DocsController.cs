﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP_API_Clientes.Controllers
{
    /// <summary>
    /// Controller para exibir a documentação da API de Clientes
    /// </summary>
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DocsController : Controller
    {
        [Route(""), HttpGet]
        [AllowAnonymous]
        public IActionResult Swagger()
        {
            return Redirect("~/swagger");
        }
    }
}