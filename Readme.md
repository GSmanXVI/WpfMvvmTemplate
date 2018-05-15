# WPF MVVM Project Template
Basic template for new WPF MVVM Project with MVVMLight and Autofac

## How to add a new View:
1. Create **NewView** in *View* Folder
2. Create **NewViewModel** in *ViewModel* Folder
3. Add DataTemplate to *Resorces/ViewDataTemplates.xaml*
4. Add View name name to *Navigation.VM* enum
5. Add **NewViewModel** to *autofac.json*
6. Add **NewViewModel** property to *Tools.ViewModelLocator*
7. Resolve **NewViewModel** in *Tools.ViewModelLocator* using Autofac
8. Add **NewViewModel** to *Navigation.NavigationService*

## How to add a new Service:
1. Create interface in *Services* folder
2. Create interface implementation in *Services* folder
3. Add your service to *autofac.json*

## How to send message to ViewModel:
1. Create new message type in *Messages* folder
2. To send message call Messenger.Default.Send(new **MessageType**() \{ ... })
3. To recieve messages call Messenger.Default.Register<**MessageType**>(...) in reciever constructor


## Dependencies
- [MVVMLight](http://www.mvvmlight.net/)
- [Autofac](https://autofac.org/)
