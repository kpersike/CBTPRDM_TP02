/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
namespace TarefasApp;

public partial class TarefaDetailsPage : ContentPage
{
	private readonly ListViewDemos.ViewModels.TarefasViewModel viewModel;

	public TarefaDetailsPage(Tarefa tarefa, ListViewDemos.ViewModels.TarefasViewModel vm)
	{
		InitializeComponent();

		// Define o BindingContext como a própria instância do modelo Tarefa
		this.BindingContext = tarefa;
		viewModel = vm;
	}

	async void OnEditClicked(object sender, EventArgs e)
	{
		if (this.BindingContext is not Tarefa original)
			return;

		await Navigation.PushModalAsync(new NavigationPage(new TarefaEditPage(original)));
	}

	async void OnDeleteClicked(object sender, EventArgs e)
	{
		if (this.BindingContext is not Tarefa tarefa)
			return;

		bool confirm = await DisplayAlert("Confirmar", $"Deseja excluir '{tarefa.Titulo}'?", "Sim", "Não");
		if (!confirm)
			return;

		if (viewModel != null)
		{
			if (viewModel.DeleteCommand != null && viewModel.DeleteCommand.CanExecute(tarefa))
			{
				viewModel.DeleteCommand.Execute(tarefa);
			}
			else
			{
				viewModel.Tarefas.Remove(tarefa);
			}
		}

		// Fecha o modal de detalhes
		await Navigation.PopModalAsync();
	}

	async void OnBackClicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}
