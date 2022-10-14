import React from 'react';
import Axios from 'axios';
import './App.css';

function App() {

  const getContent = async () => {
    Axios.get("https://localhost:5003/ocelot/content").then((response) => {
      console.log(response);
    });
  };
  return <div>Hello Youtube <button onClick={getContent}>Get Content</button></div>
}

export default App;
