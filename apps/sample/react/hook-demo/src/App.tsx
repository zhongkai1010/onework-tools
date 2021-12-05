import React, { useContext, useState } from "react";

interface Props {}

const App = (props: Props) => {
  const [count, setCount] = useState(0);
  const config = { size: 1 };
  let { Consumer, Provider } = React.createContext(config);
  const plusClick = () => {
    setCount((values) => (values += 1));
  };
  const subtractionClick = () => {
    setCount((values) => values + -1);
  };
  return (
    <Provider value={config}>
      <div>
        <button onClick={subtractionClick}>-</button>
        {count}
        <button onClick={plusClick}>+</button>
      </div>
    </Provider>
  );
};

const OperateButton = (props: Props) => {
  
  return <button onClick={plusClick}>+</button>;
};

export default App;
