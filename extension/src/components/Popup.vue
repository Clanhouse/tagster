<template>
  <div>
    <h2>Tagster is working!!</h2>
    <a
        target="_blank"
        href="https://linkedin.com"
        id="checkPage"
        class="button button2"
    >Go and tag some people</a
    >
    <a id="searchNames" class="button button3" @click="consoleLog">Search people</a>
    <a class="button button3" @click="loginWithGoogle">Google login</a>
    <div v-if="testGoogleLoginResult">
      <p>Google login result</p>
      <pre>{{testGoogleLoginResult}}</pre>
    </div>

  </div>
</template>

<script>

export default {
  name: "Popup",
  data() {
    return {
      testGoogleLoginResult: null,
    }
  },
  methods: {
    consoleLog: function () {
      browser.runtime.sendMessage("hi");
    },
    createOAuth2Url: function() {
      let nonce = Math.random().toString(36).substring(2, 15);
      const authUrl = new URL('https://accounts.google.com/o/oauth2/v2/auth');

      authUrl.searchParams.set('client_id', `634811800702-61mu4vjnd3ntsgvnpielgv0epb0anj7m.apps.googleusercontent.com`);
      authUrl.searchParams.set('response_type', `id_token`);
      authUrl.searchParams.set('redirect_uri', chrome.identity.getRedirectURL(`oauth2`));
      authUrl.searchParams.set('scope', 'openid email');
      authUrl.searchParams.set('nonce', nonce);
      authUrl.searchParams.set('prompt', 'consent');

      return authUrl.href;
    },
    loginWithGoogle: function () {
      let vueThis = this;
      chrome.identity.launchWebAuthFlow({
        url: this.createOAuth2Url(),
        interactive: true
      }, function (redirect_uri) {
        const urlHash = redirect_uri.split('#')[1];
        const params = new URLSearchParams(urlHash);
        const token = params.get('id_token');

        chrome.runtime.sendMessage(
            {type: "GOOGLE_AUTH", idToken: token}, function (response) {
              vueThis.testGoogleLoginResult = response.data;
            }
        );
      })
    }
  },
  mounted() {
    browser.runtime.sendMessage({});
  },
};
</script>

<style scoped>
.button {
  background-color: #4caf50;
  border: none;
  color: black;
  padding: 5px 14px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  transition-duration: 0.4s;
  cursor: pointer;
}

.button2 {
  background-color: white;
  color: black;
  border: 2px solid #008cba;
}

.button2:hover {
  background-color: #008cba;
  color: white;
}

.button3 {
  background-color: white;
  color: black;
  border: 2px solid #c22b05;
}

.button3:hover {
  background-color: #c22b05;
  color: white;
}
</style>
