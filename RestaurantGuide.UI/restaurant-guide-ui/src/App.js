import logo from './logo.svg';
import './App.css';
import GuestList from './guests/components/GuestList';

function App() {
 
 const guests = [  {
    email: "roma.loginovskiy@gmail.com",
    firstName: "Roma",
    lastName: "Loginovskiy"
 },
 {
  email: "roma.loginovskiy1@gmail.com",
  firstName: "Roma",
  lastName: "Loginovskiy"
},
{
  email: "roma.loginovskiy2@gmail.com",
  firstName: "Roma",
  lastName: "Loginovskiy"
}
 ];
  return (
    <div className="App">
      <GuestList guests={guests}></GuestList>
    </div>
  );
}

export default App;
