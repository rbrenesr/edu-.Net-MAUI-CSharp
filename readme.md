# Curso de .NET MAUI con Visual Studio 2022 creando PROYECTOS
## Hector Uriel Pérez
### https://elcamino.dev/

# Seccion 1 - Introducción
- Instalación de Visual Studio 2022
- Hablitar Emulador Android

# Seccion 2 - Introducción lengiaje XAML
- XAML: Lenguaje de mercado para diseño gráfico en MAUI
- App.xaml: se especifica cual es el archivo inicial de la aplicación


# Seccion 3 - Páginas

### ContentPage
- Tipo de página que nos permite agregar Layouts y controles (más utilizadas)
- Sólo puede contener un elemento como nivel raíz en la gerarquía

### NavigationPage
- Pila de navegacion

```
//Permite realizar la nagevación
Navigation.PushAsync(new ContentPageDemo());

// Permite quitar la página de la pila de navegación
Navigation.PopAsync();
```

```
// NavigationPage Nos permite enrutar la navegación, pues si  este encapsulado el proceso no es permitido (sin error)

//En App.xaml
MainPage = new NavigationPage(new MainPage());

// Para modificar su estrucura
NavigationPage navigationPage = new NavigationPage(new MainPage());
MainPage = navigationPage;

```
**Importante**  
-> Si se usa Navigation para navegar entre páginas, se realiza una instancia nueva de cada página, por lo que si hacemos este proceso de forma bidireccional, el contenido de una página por ejemplo de un input se perdera pues es una página nueva, por eso se usa el push/pop async


### FlyoutPage
- Utilizada como estilo menu bar para navegación.
- Al crear una nueva página de tipo COntectPage, se debe cambiar las etiquetas a FlyoutPage
- Se debe modificar la herencia de la página en el cs ```public partial class FlyoutPageDemo : ContentPage por FlyoutPage```
- Porpiedades FlyoutLayoutBehavior

```
<?xml version="1.0" encoding="utf-8" ?>
<FlyoutPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PagesDemo.FlyoutPageDemo"
             Title="FlyoutPageDemo"
            FlyoutLayoutBehavior="Popover">

    <FlyoutPage.Flyout>
        <ContentPage Title="My App" BackgroundColor="Azure">
            <Label
                Text="Label from flyout"
                HorizontalTextAlignment="Center"
                VerticalTextAlignment="Center"
                ></Label>
        </ContentPage>
    </FlyoutPage.Flyout>

    <FlyoutPage.Detail>
        <ContentPage BackgroundColor="Indigo">
            <Label
       Text="Label from detail"
       HorizontalTextAlignment="Center"
       VerticalTextAlignment="Center"
       ></Label>

        </ContentPage>
    </FlyoutPage.Detail>
</FlyoutPage>
```

### TabbedPage
- Página basada en pestañas

```
<?xml version="1.0" encoding="utf-8" ?>
<TabbedPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PagesDemo.TabbedPageDemo"
             Title="TabbedPageDemo"
            BarBackgroundColor="DarkBlue"
            BarTextColor="White"
            SelectedTabColor="DarkRed"
            UnselectedTabColor="DarkCyan">

    <ContentPage Title="Page 1" IconImageSource="dotnet_bot.png"></ContentPage>
    <ContentPage Title="Page 2" IconImageSource="dotnet_bot.png"></ContentPage>
    <ContentPage Title="Page 2" IconImageSource="dotnet_bot.png"></ContentPage>
    
</TabbedPage>
```


# Seccion 4 - Layouts

Diferentes tipos de layouts

![Layouts](assets/layouts01.png)


### StackLayout

- Organiza los elementos en uan pila unidireccional ya sea verticar u horizontalmente.
- Se organiza nosrmalmente para organizar una subsección de una página
- SctackLayout == VerticalStackLayout


### GridLayout

- Definición de medidas 

```
Auto = justo el tamaño del control contenido
valor ejmp 100 = el valor de unidades especificado
* = Todo el espacio disponible
.4* = aplicado de manera porcentual
```

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="GridLayoutDemo.GridLayoutDemo"
             Title="GridLayoutDemo">
    <!--<Grid Background="Aqua" RowSpacing="10">-->
        <Grid RowDefinitions=".2*, .8*" ColumnDefinitions="30,*" Background="Aqua" RowSpacing="10">
        <!--<Grid.RowDefinitions>
            <RowDefinition Height=".1*"/>
            <RowDefinition Height=".9*"/>
        </Grid.RowDefinitions>

        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>-->

        <Button  HeightRequest="200"
            Text="Welcome to .NET MAUI!"/>
        
        <Button 
            Text="Btn #2"            
            Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="2"/>
    </Grid>
</ContentPage>
```

# Seccion x - 