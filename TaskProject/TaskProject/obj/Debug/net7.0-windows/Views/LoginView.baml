   M S B A M L   `   `   `  ????F  BTaskProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TaskProject.ViewsTaskProject.Views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      K GAdvancedControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:AdvancedControls;assembly=AdvancedControlsAdvancedControls 5      !    TaskProject.Views.LoginView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TaskProject.Views     5      6sys&clr-namespace:System;assembly=mscorlib     5      Gac8clr-namespace:AdvancedControls;assembly=AdvancedControls     5         
CommonText#??[  5        ? 	Resources  5       ?? 
TargetType  CommonButton ?? BasedOn??%4   '??       7  ?? 5   
   " ??6   8   5      5      .??5      ?? $??Center=?6   $??Center=?5      $	??335??5      .+?5   
   ?? $??24(?6   $-??'Вход в учетную запись??5      $??0 0 0 5q?5      ?? 5   
   $??ФИО??6   $
??Bold"?5      ?? 5   
   ??6   ?? *
FullName+ ?? UpdateSourceTrigger$ PropertyChanged=??? 5   
   $??Дата рождения??6   (  "System.Windows.Controls.DatePicker  5   
      DisplayDateStart 
1950.01.015       ?? Today   DisplayDateEnd# Z 5         SelectedDateFormat$
 Long=?5         SelectedDate 5      ?? *	BirthDate+  5       	 ?? DataType??%g   (??       5!      *,??+)?? 6   "	 ??6   .R?5"      ?? $??15(?6    ??5#       ?? 5$      5%      5&      ?? 5'   
   $??Телефон??6   ?? 5(   
   ??6   ?? *Phone+$ PropertyChanged=??? 5)   
   $??
ЛОГИН??6   ?? 5*   
   ??6   ?? *Login+$ PropertyChanged=??? 5+   
   $??ПАРОЛЬ??6   "  AdvancedControls.PasswordBox  5,   
   
   Password
 6   ?? *
Password+$ PropertyChanged=??? 5-   
   $&?? Зарегистрировать??6   $
??0 10q?5/      ??5.      ?? *AddEmployee+ ?? Mode$ OneTime=?5/      ?? 50   
   $-??'Просмотр сотрудников??6   ??51      ?? *EmployeeList+$ OneTime=?52      53      