import { CalculateScore } from './components/CalculateScore';

function App() {
  return (
    <div>
      <CalculateScore 
        Name={"Steeve"}
        School={"Public School"}
        total={284}
        goal={300}
      />
    </div>
  );
}

export default App;
