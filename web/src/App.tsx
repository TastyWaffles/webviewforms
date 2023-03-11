import { useEffect, useState } from 'react';
import { z } from 'zod';
import './App.css';
import MainDisplay from './MainDisplay';
import { AuthenticationMessage, ItemMessage } from './ZodObjects';

function App() {
  const [data, setData] = useState<z.infer<typeof ItemMessage>[]>([]);
  const [loggedIn, setLoggedIn] = useState(false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const win = window as any;
    win.receiveMessageFromWinForms = (msg: string) => {
      console.log(msg);
    };

    win.receiveLogin = (auth: string) => {
      const authenticated = AuthenticationMessage.parse(
        JSON.parse(auth)
      ).authenticated;

      setLoggedIn(authenticated);
      setLoading(true);
      window.chrome.webview.postMessage(JSON.stringify({ type: 'GET_DATA' }));
    };

    win.receiveData = (data: string) => {
      const records = ItemMessage.array().parse(JSON.parse(data));
      setData([...records]);
      setLoading(false);
    };
  }, []);

  if (loading) {
    return <div>loading</div>;
  } else if (loggedIn) {
    return <MainDisplay data={data} />;
  } else {
    return (
      <button
        type="button"
        onClick={() =>
          window.chrome.webview.postMessage(
            JSON.stringify({
              type: 'LOGIN',
              payload: { username: 'blah', password: 'test' },
            })
          )
        }
      >
        Log In
      </button>
    );
  }
}

export default App;
