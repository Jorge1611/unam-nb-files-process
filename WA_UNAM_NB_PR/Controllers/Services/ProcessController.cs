using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WA_UNAM_NB_PR.Hubs;

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
            var _statusLetra = (ProcessManager.Instance.Status == 0) ? "En espera" : "Trabajando";
            return Ok(_statusLetra);
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
            var _statusLetra = (ProcessManager.Instance.Status == 0) ? "En espera" : "Trabajando";
            return Ok(_statusLetra);
        }

    }

    public class ProcessManager : IProcessManager
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
        public int Status { get; private set; }
        private ProcessManager()
        {
            Debug.WriteLine("Inicio unico del constructor");
            Status = (int)ProcesoStatus.EnEspera;
        }

        /// <summary>
        /// Lanza la tarea. Cambia el estatus a trabajando esperando 20 segundos y termina la tarea
        /// </summary>
        /// <returns> tarea </returns>
        public Task Go()
        {
            _tokenSource = new CancellationTokenSource();
            _myToken = _tokenSource.Token;
            _task = Task.Factory.StartNew(() =>
            {
                UpdateStatus((int)ProcesoStatus.Trabajando);
                Debug.WriteLine("Estatus = Trabajando");
                Thread.Sleep(20000);
                UpdateStatus((int)ProcesoStatus.EnEspera);
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
                    UpdateStatus((int)ProcesoStatus.EnEspera);
                    Debug.WriteLine("Estatus = En espera");
                }
            }            
        }
        
        public void UpdateStatus(int value)
        {
            Status = value;
            var connection = GlobalHost.ConnectionManager.GetHubContext<ProcessHub>();
            if(connection != null)
                connection.Clients.All.getupdate();
        }
    }
}