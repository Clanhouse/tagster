import axios from "axios";

// axios.get("https://localhost:5001/Tags/Nickole").then((response) => {
//   console.log(response);
// });

async function sendData(sendResponse) {
  axios.get("https://localhost:5001/Tags/Nickole").then((response) => {
    let data = response.data;
    sendResponse({ data });
  });
}

chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
  if (request.type === "GET_DATA") {
    console.log(request.link);
    sendData(sendResponse);
  }
  return true;
});

// async function sendFoo(sendResponse) {
//   axios.get("https://localhost:5001/Tags/Nickole").then((response) => {
//     console.log(response);
//     sendResponse("response");
//   });
// }

// chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
//   let tr = true;
//   if (tr) {
//     sendFoo(sendResponse);
//     return true;
//   }
// });
