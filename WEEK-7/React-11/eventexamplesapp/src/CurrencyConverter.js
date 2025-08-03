import React, { useState } from 'react';

const CurrencyConvertor = () => {
  const [rupees, setRupees] = useState('');
 

  
  const handleSubmit = (event) => {
    event.preventDefault();
    const rupeesAmount = parseFloat(rupees);
    
    if (!isNaN(rupeesAmount)) {
      // Conversion rate: 1 EUR = 90 INR (approximate)
      const euroAmount = (rupeesAmount / 90).toFixed(2);
      alert(`Converting to Euro Amount is €${euroAmount}`);
    } else {
      alert('Please enter a valid number');
    }
  };

  // Handle input change
  const handleInputChange = (event) => {
    setRupees(event.target.value);
  };

  return (
    <div className="currency-converter">
      <h1 style={{color: 'green'}}>Currency Converter!!</h1>
      <div className="converter-form">
        <label>
          Indian Rupees:
          <input 
            type="number" 
            value={rupees}
            onChange={handleInputChange}
            placeholder="Enter amount in INR"
          />
        </label>
        <button onClick={handleSubmit}>Convert</button>
      </div>
    </div>
  );
};

export default CurrencyConvertor;
