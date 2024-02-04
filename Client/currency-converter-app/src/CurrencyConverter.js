import React, { useState, useEffect } from "react";

export const CurrencyConverter = () => {
  let input = React.createRef();
  const [result, setResult] = useState(undefined);
  const [inputValue, setInputValue] = useState(undefined);
  useEffect(() => {
    if(inputValue){
        fetch("https://localhost:7150/api/v1/GetCurrencyInWords?currency=" + encodeURIComponent(inputValue))
        .then((response) => response.text())
        .then((data) => {
          console.log(data);
          setResult(data);
        })
        .catch((err) => {
          console.log(err.message);
        });
    }
    
  }, [inputValue]);

  //   handleChange(event) {
  // this.setState({value: event.target.value});
  //   }

  //   handleSubmit(event) {
  // alert('An essay was submitted: ' + this.state.value);
  // event.preventDefault();
  //   };

  //return <h1>{inWords}</h1>;

  let handleSubmit = (event) => {
    setInputValue(input.current.value);
    // alert("A name was submitted: " + input.current.value);
    event.preventDefault();
  };

  return (
    <div className="container">
        <h1>{result}</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Name:
          <input type="text" ref={input} />
        </label>
        <input type="submit" value="Submit" />
      </form>
    </div>
  );
};
