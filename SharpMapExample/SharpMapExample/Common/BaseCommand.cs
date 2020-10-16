/**********************************************************************
** Copyright © 2020 广州南方智能技术有限公司 All rights reserved.
***********************************************************************
** CLR 版本:4.0.30319.42000
** 创建时间:2020/10/16 14:30:08
** 作    者:GuoYingdong
** 说    明:
** ============================== 修改 ============================== **
** 修改时间:
** 作    者:
** 说    明:
**********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SharpMapExample.Common
{
    /// <summary>
    /// 实现ICommand接口
    /// </summary>
    public class BaseCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<T> _execute = null;
        public Func<T, bool> _canExecute = null;

        public BaseCommand(Action<T> execute) : this(execute, null)
        {
            if (execute != null)
            {
                this._execute = new Action<T>(execute);
            }
        }

        public BaseCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (canExecute != null)
            {
                this._canExecute = new Func<T, bool>(canExecute);
            }
            if (execute != null)
            {
                this._execute = new Action<T>(execute);
            }
        }

        public void RaiseCanExceuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecute == null)
            {
                return true;
            }
            return _canExecute((T)(object)(parameter));
        }

        public void Execute(object parameter)
        {
            this._execute((T)(object)(parameter));
        }
    }

    public class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action _execute = null;
        public Func<bool> _canExecute = null;

        public BaseCommand(Action execute) : this(execute, null)
        {
            if (execute != null)
            {
                this._execute = new Action(execute);
            }
        }

        public BaseCommand(Action execute, Func<bool> canExecute)
        {
            if (canExecute != null)
            {
                this._canExecute = new Func<bool>(canExecute);
            }
            if (execute != null)
            {
                this._execute = new Action(execute);
            }
        }

        public void RaiseCanExceuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecute == null)
            {
                return true;
            }
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            this._execute();
        }
    }

}
