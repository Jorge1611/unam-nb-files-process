using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace WA_UNAM_NB_PR.Controllers.Services
{
    public class ProcesoController : ApiController
    {
        //[HttpGet]
        //[ActionName("run")]
        //public async Task<IHttpActionResult> GoAsyn()
        //{

        //    var _ManagerProcesor = ManagerProcesor.Instance;
        //    if (_ManagerProcesor.Estatus == 0) // 0 es espera
        //    {
        //        await _ManagerProcesor.Go();
        //    }
        //    return Ok(_ManagerProcesor.Estatus);
        //}

        [HttpGet]
        [Route("api/proceso/go")]
        public IHttpActionResult Go()
        {

            var _ManagerProcesor = ManagerProcesor.Instance;
            if (_ManagerProcesor.Estatus == (int)ProcesoStatus.EnEspera)
            {
                _ManagerProcesor.Go();
            }
            return Ok(_ManagerProcesor.Estatus);
        }


        [HttpGet]
        [Route("api/proceso/stop")]
        public IHttpActionResult Stop()
        {

            var _ManagerProcesor = ManagerProcesor.Instance;
            if (_ManagerProcesor.Estatus == (int)ProcesoStatus.Trabajando) 
            {
                _ManagerProcesor.Stop();
            }
            return Ok(_ManagerProcesor.Estatus);
        }


    }


    public class ManagerProcesor
    {
        private CancellationTokenSource _tokenSource;
        private CancellationToken _myToken;
        
        //private readonly Task _task;
        private readonly static ManagerProcesor _instance = new ManagerProcesor();
        private Task _task;

        public static ManagerProcesor Instance {
            get {
                return _instance;
            }
        }

        public int Estatus { get; private set; }

        public ManagerProcesor()
        {
            Debug.WriteLine("Constructor Manager Procesor");
            ChangeEstatus(0);
        }

        public Task Go()
        {
            _tokenSource = new CancellationTokenSource();
            _myToken = _tokenSource.Token;

            _myToken = new CancellationToken();
            _task = Task.Factory.StartNew(() =>  {
                ChangeEstatus((int)ProcesoStatus.Trabajando);
                Debug.WriteLine("Estatus = Trabajando");
                Thread.Sleep(60000);
                Debug.WriteLine("Estatus = En espera");
                ChangeEstatus((int)ProcesoStatus.Trabajando);                                
            }, _myToken );
            
            
            return _task;
        }

        
      
        public void Stop()
        {
            
            if (_task != null)
            {
                // stop !!! 
                // val y act del estatus
                //var ctk = Task.Factory.CancellationToken;
                _tokenSource.Cancel();

                if (_tokenSource.IsCancellationRequested)
                {
                    Debug.WriteLine("Proceso Cancelado");
                    ChangeEstatus((int)ProcesoStatus.EnEspera);
                    Debug.WriteLine("Estatus = En espera");
                }
                

            }
            //return _task;

        }


        private IHubContext _IHubContext;
        public void SetHub(IHubContext _IHubContext)
        {
            this._IHubContext = _IHubContext;
        }
        private void ChangeEstatus(int estatus)
        {
            Estatus = estatus;
            if (_IHubContext != null)
                _IHubContext.Clients.All.update(estatus);
        }
    }

    enum ProcesoStatus { EnEspera = 0, Trabajando = 1 }
    }

   
