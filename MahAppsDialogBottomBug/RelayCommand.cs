using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahAppsDialogBottomBug
{
  using System.Windows.Input;

  /// <summary>The relay command.</summary>
  /// <typeparam name="T">The typeparam</typeparam>
  public class RelayCommand<T> : ICommand
  {
    #region Fields

    /// <summary>The can execute.</summary>
    private readonly Func<T, bool> canExecute;

    /// <summary>The execute.</summary>
    private readonly Action<T> execute;

    #endregion

    #region Constructors and Destructors

    /// <summary>Initializes a new instance of the <see cref="RelayCommand{T}"/> class.</summary>
    /// <param name="execute">The execute.</param>
    /// <param name="canExecute">The can execute.</param>
    public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
    {
      this.execute = execute;
      this.canExecute = canExecute;
    }

    #endregion

    #region Public Events

    /// <summary>The can execute changed.</summary>
    public event EventHandler CanExecuteChanged
    {
      add
      {
        if (this.canExecute != null)
        {
          CommandManager.RequerySuggested += value;
        }
      }

      remove
      {
        if (this.canExecute != null)
        {
          CommandManager.RequerySuggested -= value;
        }
      }
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>The can execute.</summary>
    /// <param name="parameter">The parameter.</param>
    /// <returns>The System.Boolean.</returns>
    public bool CanExecute(object parameter)
    {
      return (this.canExecute == null) || this.canExecute((T)parameter);
    }

    /// <summary>The execute.</summary>
    /// <param name="parameter">The parameter.</param>
    public void Execute(object parameter)
    {
      this.execute((T)parameter);
    }

    #endregion
  }
}
