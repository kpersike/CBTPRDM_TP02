/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TarefasApp;

namespace ListViewDemos.ViewModels
{
    public class TarefasViewModel : INotifyPropertyChanged
    {
        readonly IList<Tarefa> source;
        Tarefa selectedTarefa;

        public ObservableCollection<Tarefa> Tarefas { get; private set; }

        public Tarefa SelectedTarefa
        {
            get => selectedTarefa;
            set
            {
                if (selectedTarefa != value)
                {
                    selectedTarefa = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand DeleteCommand => new Command<Tarefa>(RemoveTarefa);

        public TarefasViewModel()
        {
            source = new List<Tarefa>();
            CreateTarefaCollection();

            SelectedTarefa = Tarefas.FirstOrDefault();
            OnPropertyChanged("SelectedTarefa");
        }

        void CreateTarefaCollection()
        {
            source.Add(new Tarefa
            {
                Titulo = "Comprar mantimentos",
                Descricao = "Comprar leite, pão e ovos",
                DataCriacao = DateTime.Now.AddDays(-2),
                Prioridade = "Alta"
            });

            source.Add(new Tarefa
            {
                Titulo = "Enviar relatório",
                Descricao = "Enviar relatório semanal ao gerente",
                DataCriacao = DateTime.Now.AddDays(-1),
                Prioridade = "Média"
            });

            source.Add(new Tarefa
            {
                Titulo = "Estudar MAUI",
                Descricao = "Rever navegação e bindings",
                DataCriacao = DateTime.Now,
                Prioridade = "Baixa"
            });

            Tarefas = new ObservableCollection<Tarefa>(source);
        }

        void RemoveTarefa(Tarefa tarefa)
        {
            if (Tarefas.Contains(tarefa))
            {
                Tarefas.Remove(tarefa);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}