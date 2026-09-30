/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
using System.Xml.Linq;

namespace TarefasApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            // Define o BindingContext para que a propriedade "Monkeys" exista para o XAML
            this.BindingContext = new ListViewDemos.ViewModels.TarefasViewModel();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            var vm = this.BindingContext as ListViewDemos.ViewModels.TarefasViewModel;
            if (vm == null)
                return;

            // Abre modal para adicionar nova Tarefa
            await Navigation.PushModalAsync(new NavigationPage(new TarefaAddPage(vm)));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = e.CurrentSelection.FirstOrDefault() as Tarefa;
            if (current == null)
                return;

            var vm = this.BindingContext as ListViewDemos.ViewModels.TarefasViewModel;
            await Navigation.PushModalAsync(new NavigationPage(new TarefaDetailsPage(current, vm)));

            // limpa seleção
            if (sender is CollectionView cv)
                cv.SelectedItem = null;
        }
    }
}
