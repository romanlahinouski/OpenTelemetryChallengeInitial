import "./Guest.css";

function Guest(props) {
    return(

        <div className="guest-main">
           {console.log(props.email)}
        <div>{props.email}</div>
        <div>{props.firstName}</div>
        <div>{props.lastName}</div>
        </div>
    )
}

export default Guest;