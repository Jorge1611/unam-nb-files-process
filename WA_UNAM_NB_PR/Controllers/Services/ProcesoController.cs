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
        [ActionName("go")]
        public IHttpActionResult Go()
        {

            var _ManagerProcesor = ManagerProcesor.Instance;
            if (_ManagerProcesor.Estatus == 0) // 0 es espera
            {
                _ManagerProcesor.Go();
            }
            return Ok(_ManagerProcesor.Estatus);
        }


    }


    public class ManagerProcesor
    {
        //private readonly Task _task;
        private readonly static ManagerProcesor _instance = new ManagerProcesor();
        private Task _task;

        public static ManagerProcesor Instance {
            get {
                return _instance;
            }
        }

        public int Estatus { get; set; }

        public ManagerProcesor()
        {
            Debug.WriteLine("Contructor Manager Procesor");
            Estatus = 0;
        }

        public Task Go()
        {
            _task = Task.Factory.StartNew(() => {
                Estatus = 1;
                Debug.WriteLine("Estatus = 1");
                Thread.Sleep(20000);
                Debug.WriteLine("Estatus = 0");
                Estatus = 0;
            });
            return _task;
        }

        public void Stop()
        {
            if (_task != null)
            {
                // stop !!! 
                // val y act del estatus
            }
        }
    }


    
}
