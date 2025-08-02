import React from 'react';
import ListofPlayers from './ListofPlayers';
import IndianPlayersComponent, { OddPlayers, EvenPlayers, IndianPlayers } from './IndianPlayers';
import './App.css';

function App() {
  const players = [
    { name: 'Virat', score: 85 },
    { name: 'Rohit', score: 92 },
    { name: 'Dhoni', score: 65 },
    { name: 'Hardik', score: 78 },
    { name: 'Jadeja', score: 55 },
    { name: 'Bumrah', score: 45 },
    { name: 'Shami', score: 40 },
    { name: 'Rahul', score: 88 },
    { name: 'Pant', score: 72 },
    { name: 'Kohli', score: 95 },
    { name: 'Iyer', score: 68 }
  ];

  const IndianTeam = ['Player1', 'Player2', 'Player3', 'Player4', 'Player5', 'Player6'];
  
  var flag = false;

  if(flag === true) {
    return (
      <div>
        <h1>List of Players</h1>
        <ListofPlayers players={players} />
      </div>
    );
  }
  
  return (
    <div>
      <h1>Indian Team</h1>
      <h1>Odd Players</h1>
      <OddPlayers players={IndianTeam} />
      <h1>Even Players</h1>
      <EvenPlayers players={IndianTeam} />
      <h1>List of Indian Players Merged:</h1>
      <IndianPlayersComponent IndianPlayers={IndianPlayers} />
    </div>
  );
}

export default App;
