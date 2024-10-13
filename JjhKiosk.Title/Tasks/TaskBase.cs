using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JjhKiosk.Title.Tasks
{
    public abstract class TaskBase
    {
        private EventWaitHandle taskHandle;

        protected Task task;

        protected EventWaitHandle TaskHandle => taskHandle;

        public TaskBase()
        {
            taskHandle = new EventWaitHandle(initialState: false, EventResetMode.ManualReset);
        }

        public abstract void Run();

        public virtual void Close()
        {
            taskHandle.Set();
            task?.Wait();
        }

        public virtual void Close(int timeout)
        {
            taskHandle.Set();
            task?.Wait(timeout);
        }

        public virtual void Restart()
        {
            taskHandle.Reset();
        }
    }
}
