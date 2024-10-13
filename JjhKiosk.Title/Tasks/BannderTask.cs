using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.Title.Tasks
{
    public class BannderTask : TaskBase
    {
        public override async void Run()
        {
            //베너 회전 테스크
            task = Task.Run(() =>
            {

            });

            await task;
        }
    }
}
