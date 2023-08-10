class QueryString {
  static GetRandomStr() {
    return "urlbust=" + Math.random().toString(36).slice(2);
  }
}
