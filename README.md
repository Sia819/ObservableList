# ObservableList
From now on, you can write ObservableCollection &lt;T> like List &lt;T>.

ObservableCollection 대신 List 클래스를 데이터바인딩 할 수 있는 클래스  
List에는 구현되어있고, ObservableCollection 에서 할 수 없었던 행동을  
이제 ObservableList를 통해서 할 수 있습니다.  

기본적으로 WPF의 ViewModel에서 List<T> 를 사용하면 PropertyChanged 이벤트가 발생하지 않는데,  
그것때문에 ObservableCollection를 사용하여 제약적으로 사용하게 됩니다.  
List<T>클래스에서 PropertyChanged 이벤트가 발생하고,  
이외 모든것이 동일하다고 보시면 됩니다.
