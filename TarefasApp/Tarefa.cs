/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
using System;
using System.ComponentModel;

namespace TarefasApp
{
    public class Tarefa : INotifyPropertyChanged
    {
        private string titulo;
        private string descricao;
        private DateTime dataCriacao;
        private string prioridade;

        public string Titulo
        {
            get => titulo;
            set
            {
                if (titulo == value) return;
                titulo = value;
                OnPropertyChanged(nameof(Titulo));
            }
        }

        public string Descricao
        {
            get => descricao;
            set
            {
                if (descricao == value) return;
                descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }

        public DateTime DataCriacao
        {
            get => dataCriacao;
            set
            {
                if (dataCriacao == value) return;
                dataCriacao = value;
                OnPropertyChanged(nameof(DataCriacao));
            }
        }

        public string Prioridade
        {
            get => prioridade;
            set
            {
                if (prioridade == value) return;
                prioridade = value;
                OnPropertyChanged(nameof(Prioridade));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
