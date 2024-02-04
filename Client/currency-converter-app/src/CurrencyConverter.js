import React, { useState, useEffect } from "react";

export const CurrencyConverter = () => {
  const [inWords, setInWords] = useState(undefined);
  useEffect(() => {
    fetch("https://localhost:7150/api/v1/GetCurrencyInWords?currency=123%2C10")
      .then((response) => response.text())
      .then((data) => {
        console.log(data);
        setInWords(data);
      })
      .catch((err) => {
        console.log(err.message);
      });
  }, []);

  return <h1>{inWords}</h1>;
};
