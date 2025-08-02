import React from 'react';

const ListofPlayers = ({ players }) => {
  const players70 = [];
  
  return (
    <div>
      <h2>All Players</h2>
      <ul>
        {players.map((item, index) => (
          <li key={index}>
            Mr. {item.name} <span>{item.score}</span>
          </li>
        ))}
      </ul>
      
      <h2>Players with Score Below 70</h2>
      <ul>
        {players.map((item, index) => {
          if(item.score <= 70) {
            players70.push(item);
            return (
              <li key={index}>
                Mr. {item.name} <span>{item.score}</span>
              </li>
            );
          }
          return null;
        })}
      </ul>
    </div>
  );
};

export default ListofPlayers;
