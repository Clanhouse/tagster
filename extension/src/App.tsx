import React from 'react';

function App() {
  React.useEffect(() => {
    // TODO this is how you send an event from react app. Can remove
    // chrome.tabs && chrome.tabs.query({
    //   active: true,
    //   currentWindow: true
    // }, tabs => {
    //   chrome.tabs.sendMessage(
    //       tabs[0].id || 0,
    //       {type: 'UPDATE_TAGS'} as UpdateTagsMessage,
    //       (response: UpdateTagsResponse) => {
    //         console.log("Got response: " + response)
    //       });
    // });
  });

  return (
    <div className='App'>
      <header className='App-header'>
        <p>Login buttons and maybe some settings here.</p>
      </header>
    </div>
  );
}

export default App;
