import { LmycClientPage } from './app.po';

describe('lmyc-client App', function() {
  let page: LmycClientPage;

  beforeEach(() => {
    page = new LmycClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
