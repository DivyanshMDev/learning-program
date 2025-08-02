import React from 'react';
import './App.css';

function App() {
  
  const element = <h1>Office Space</h1>;

  
  const jsxatt = <img src="/office-space.png" width="25%" height="25%" alt="Office Space"/>;

  
  const office = {
    Name: 'Cognizant',
    Rent: 50000,
    Address: 'Chennai'
  };

 
  const officeList = [
    { Name: 'Cognizant', Rent: 50000, Address: 'Chennai' },
    { Name: 'Luxury Office', Rent: 75000, Address: 'Mumbai' },
    { Name: 'Budget Office', Rent: 40000, Address: 'Bangalore' },
    { Name: 'Corporate Office', Rent: 90000, Address: 'Delhi' },
    { Name: 'Startup Office', Rent: 35000, Address: 'Pune' }
  ];

  return (
    <div className="App">
      {element}
      {jsxatt}
      
      <h2>Office at Affordable Range</h2>
      <div>
        <h3>Name: {office.Name}</h3>
        <h3 className={office.Rent <= 60000 ? 'textRed' : 'textGreen'}>
          Rent Rs. {office.Rent}
        </h3>
        <h3>Address: {office.Address}</h3>
      </div>

      <h2>All Office Spaces</h2>
      {officeList.map((itemName, index) => {
        let colors = [];
        if (itemName.Rent <= 60000) {
          colors.push('textRed');
        } else {
          colors.push('textGreen');
        }
        
        return (
          <div key={index} style={{ marginBottom: '20px', border: '1px solid #ccc', padding: '10px' }}>
            <h3>Name: {itemName.Name}</h3>
            <h3 className={colors[0]}>Rent Rs. {itemName.Rent}</h3>
            <h3>Address: {itemName.Address}</h3>
          </div>
        );
      })}
    </div>
  );
}

export default App;
