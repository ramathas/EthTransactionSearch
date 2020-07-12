import React, { Component } from 'react';

export class About extends Component {
    static displayName = About.name;

  constructor(props) {
    super(props);    
  }   

  render() {
    return (
      <div>
        <h1>About</h1>
        <p>This application is developed with .Net core back end and react front end</p>
        <p aria-live="polite"><strong></strong></p>        
      </div>
    );
  }
}
