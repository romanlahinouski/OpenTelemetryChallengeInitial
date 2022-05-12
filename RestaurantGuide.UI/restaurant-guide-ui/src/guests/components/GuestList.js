import Guest from "./Guest";

function GuestList(props) {
    
    
 return(
    <div>
        {console.log(props.guests)}
    <ul>
        {props.guests.map(guest => <li>
                <Guest 
                    email={guest.email} 
                    firstName={guest.firstName} 
                    lastName={guest.lastName}
                    />              
        </li> )}
    </ul>
    </div>
 )

}

export default GuestList;