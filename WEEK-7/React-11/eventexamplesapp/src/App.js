import React, { useState } from 'react';
import CurrencyConvertor from './CurrencyConverter';
import './App.css';

function App() {
  const [counter, setCounter] = useState(0);

  
  const incrementValue = () => {
    setCounter(counter + 1);
  };

 
  const sayHello = () => {
    alert("Hello! This is a static message.");
  };

 
  const handleIncrement = () => {
    incrementValue();
    sayHello();
  };

  
  const handleDecrement = () => {
    setCounter(counter - 1);
  };

  
  const sayWelcome = (message) => {
    alert(`Say ${message}!`);
  };

  
  const handleOnPress = (event) => {
    alert("I was clicked");
  };

  return (
    <div className="App">
    
      
      <div className="counter-section">
        <h2>Counter: {counter}</h2>
        <div><button onClick={handleIncrement}>Increment</button></div>
        <div><button onClick={handleDecrement}>Decrement</button></div>
      </div>

      
      <div className="welcome-section">
        <button onClick={() => sayWelcome("welcome")}>Say Welcome</button>
      </div>


      <div className="onpress-section">
        <button onMouseDown={handleOnPress}>Click on me</button>
      </div>

      <CurrencyConvertor />
    </div>
  );
}

export default App;
