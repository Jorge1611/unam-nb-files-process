using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WA_UNAM_NB_PR.Controllers.Services;

namespace WA_UNAM_NB_PR.Hubs
{
    public class ProcessHub : Hub
    {
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}

        public void GetStatus()
        {
            var _ProcessManager = ProcessManager.Instance;
            int _status = _ProcessManager.Status;
            if(this.Context !=null)
                Clients.All.update(_status);
            //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ProcessHub>();
            ////if (context != null)
            //    context.Clients.All(_status);
            //Clients.All.Addvalor(_status);
            

        }





    }
}