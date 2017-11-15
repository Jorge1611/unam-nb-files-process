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
            if (_ProcessManager.Status == (int)ProcesoStatus.EnEspera)
            {
                _ProcessManager.Go();
            }
            return Ok(_ProcessManager.Status);
        }

        [HttpGet]
        [Route("api/process/stop")]
        public IHttpActionResult Stop()
        {

            var _ProcessManager = ProcessManager.Instance;
            if (_ProcessManager.Status == (int)ProcesoStatus.Trabajando)
            {
                _ProcessManager.Stop();
            }
            return Ok(_ProcessManager.Status);
        }

    }

    public class ProcessManager
    {
        private static readonly ProcessManager _instance = new ProcessManager();
        private CancellationTokenSource _tokenSource;
        private CancellationToken _myToken;
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
            Status = (int)ProcesoStatus.EnEspera;
        }

        /// <summary>
        /// Lanza la tarea. Cambia el estatus a trabajando esperando 5 segundos y termina la tarea
        /// </summary>
        /// <returns> tarea </returns>
        public Task Go()
        {
            _tokenSource = new CancellationTokenSource();
            _myToken = _tokenSource.Token;
            _task = Task.Factory.StartNew(() =>
            {
                Status = (int)ProcesoStatus.Trabajando;
                Debug.WriteLine("Estatus = Trabajando");
                Thread.Sleep(20000);
                Status = (int)ProcesoStatus.EnEspera;
                Debug.WriteLine("Estatus = En espera");
            });              
            return _task;
        }

        public void Stop()
        {
            if (_task != null)
            {
                _tokenSource.Cancel();

                if (_tokenSource.IsCancellationRequested)
                {
                    Debug.WriteLine("Proceso Cancelado");
                    Status=((int)ProcesoStatus.EnEspera);
                    Debug.WriteLine("Estatus = En espera");
                }
            }            
        }

    }
}