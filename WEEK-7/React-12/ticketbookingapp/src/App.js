import React, { useState } from 'react';
import './App.css';


function LoginButton(props) {
  return (
    <button onClick={props.onClick}>
      Login
    </button>
  );
}


function LogoutButton(props) {
  return (
    <button onClick={props.onClick}>
      Logout
    </button>
  );
}


function UserGreeting() {
  return <h1>Welcome back! You can now book tickets.</h1>;
}


function GuestGreeting() {
  return <h1>Please sign up or log in to book tickets.</h1>;
}



function UserPage() {
  return (
    <div>
      <UserGreeting />
    </div>
  );
}

function GuestPage() {
  return (
    <div>
      <GuestGreeting />
    </div>
  );
}

// Main App Component
function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLoginClick = () => {
    setIsLoggedIn(true);
  };

  const handleLogoutClick = () => {
    setIsLoggedIn(false);
  };

  return (
    <div className="App">
      <header className="app-header">
        <h1>Ticket Booking App</h1>
        <div className="auth-buttons">
          {isLoggedIn ? (
            <LogoutButton onClick={handleLogoutClick} />
          ) : (
            <LoginButton onClick={handleLoginClick} />
          )}
        </div>
      </header>

      <main>
       
        
        {isLoggedIn ? <UserPage /> : <GuestPage />}
      </main>
    </div>
  );
}

export default App;
