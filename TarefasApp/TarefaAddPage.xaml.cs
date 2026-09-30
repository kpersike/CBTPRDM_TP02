/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
namespace TarefasApp;

public partial class TarefaAddPage : ContentPage
{
    private readonly ListViewDemos.ViewModels.TarefasViewModel viewModel;
    private readonly Tarefa newModel;

    public TarefaAddPage(ListViewDemos.ViewModels.TarefasViewModel vm)
    {
        InitializeComponent();

        viewModel = vm ?? throw new ArgumentNullException(nameof(vm));

        newModel = new Tarefa { DataCriacao = DateTime.Now };
        this.BindingContext = newModel;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        // Adiciona à coleção do ViewModel
        viewModel.Tarefas.Add(newModel);

        await Navigation.PopModalAsync();
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
