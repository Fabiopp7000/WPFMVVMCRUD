using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPFMVVMCRUD.Models;
using WPFMVVMCRUD.Models.Enums;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVMCRUD.ViewModel
{
    public class FuncionariosViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<Funcionario> Funcionarios { get; private set; }
        public DeletarCommand Deletar { get; set; } = new DeletarCommand();
        public NovoCommand Novo { get; private set; } = new NovoCommand();
        public EditarCommand Editar { get; private set; } = new EditarCommand();

        private Funcionario _funcionarioSelecionado;
        public Funcionario FuncionarioSelecionado
        {
            get { return _funcionarioSelecionado; }
            set {
                  SetField(ref _funcionarioSelecionado, value);
                  Deletar.RaiseCanExecuteChanged();
                  Editar.RaiseCanExecuteChanged();
            }
        }

        public FuncionariosViewModel()
        {
            Funcionarios = new ObservableCollection<Funcionario>();
            Funcionarios.Add(new Funcionario()
            {
                Id = 1,
                Nome = "André",
                Sobrenome = "Lima",
                DataNascimento = new DateTime(1984, 12, 31),
                Sexo = Sexo.Masculino,
                EstadoCivil = EstadoCivil.Casado,
                DataAdmissao = new DateTime(2010, 1, 1)
            });

            FuncionarioSelecionado = Funcionarios.FirstOrDefault();
        }

        public class DeletarCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                var viewModel = parameter as FuncionariosViewModel;
                return viewModel != null && viewModel.FuncionarioSelecionado != null;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (FuncionariosViewModel)parameter;
                viewModel.Funcionarios.Remove(viewModel.FuncionarioSelecionado);
                viewModel.FuncionarioSelecionado = viewModel.Funcionarios.FirstOrDefault();
            }
        }

        public class NovoCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                return parameter is FuncionariosViewModel;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (FuncionariosViewModel)parameter;
                var funcionario = new Funcionario();
                var maxId = 0;
                if (viewModel.Funcionarios.Any())
                {
                    maxId = viewModel.Funcionarios.Max(f => f.Id);
                }
                funcionario.Id = maxId + 1;

                var fw = new FuncionarioWindow();
                fw.DataContext = funcionario;
                fw.ShowDialog();

                if(fw.DialogResult.HasValue && fw.DialogResult.Value)
                {
                    viewModel.Funcionarios.Add(funcionario);
                    viewModel.FuncionarioSelecionado = funcionario;
                }
            }
        }

        public class EditarCommand : BaseCommand
        {
            public override bool CanExecute(object parameter)
            {
                var viewModel = parameter as FuncionariosViewModel;
                return viewModel != null && viewModel.FuncionarioSelecionado != null;
            }

            public override void Execute(object parameter)
            {
                var viewModel = (FuncionariosViewModel)parameter;
                var cloneFuncionario = (Funcionario)viewModel.FuncionarioSelecionado.Clone();
                var fw = new FuncionarioWindow();
                fw.DataContext = cloneFuncionario;
                fw.ShowDialog();

                if(fw.DialogResult.HasValue && fw.DialogResult.Value)
                {
                    viewModel.FuncionarioSelecionado.Nome = cloneFuncionario.Nome;
                    viewModel.FuncionarioSelecionado.Sobrenome = cloneFuncionario.Sobrenome;
                    viewModel.FuncionarioSelecionado.DataNascimento = cloneFuncionario.DataNascimento;
                    viewModel.FuncionarioSelecionado.Sexo = cloneFuncionario.Sexo;
                    viewModel.FuncionarioSelecionado.EstadoCivil = cloneFuncionario.EstadoCivil;
                    viewModel.FuncionarioSelecionado.DataAdmissao = cloneFuncionario.DataAdmissao;
                }
            }
        }

    }
}
