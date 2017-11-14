using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WA_UNAM_NB_PR.Controllers.Services
{
    public class ProcessController : ApiController
    {
        
        [HttpGet]
        [Route("api/process/go")]
        public IHttpActionResult Go()
        {
            var _ProcessManager = ProcessManager.Instance;
            if (_ProcessManager.Status == 0)
            {
                _ProcessManager.Go();
            }
            return Ok(_ProcessManager.Status);
        }

    }

    public class ProcessManager
    {
        private static readonly ProcessManager _instance = new ProcessManager();
        public static ProcessManager Instance
        {
            get
            {
                return _instance;
            }
        }
        private Task _task;
        public int Status;
        private ProcessManager()
        {
            Debug.WriteLine("Inicio unico del constructor");
            Status = 0;
        }

        /// <summary>
        /// Lanza la tarea. Cambia el estatus a trabajando esperando 5 segundos y termina la tarea
        /// </summary>
        /// <returns> tarea </returns>
        public Task Go()
        {
            _task = Task.Factory.StartNew(() =>
            {
                Status = 1;
                Debug.WriteLine("Estatus = 1");
                Thread.Sleep(20000);
                Status = 0;
                Debug.WriteLine("Estatus = 0");
            });              
            return _task;
        }


    }
}