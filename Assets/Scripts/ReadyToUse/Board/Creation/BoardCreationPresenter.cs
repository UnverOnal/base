using GameManagement;
using GameManagement.LifeCycle;
using Services.PoolingService;
using VContainer;

namespace ReadyToUse.Board.Creation
{
    public class BoardCreationPresenter : IGameUnit
    {
        private readonly BoardCreationView _view;
        private readonly BoardModel _model;

        private readonly BoardFitter _boardFitter;
        
        [Inject]
        public BoardCreationPresenter(BoardModel boardModel, IPoolService poolService, BoardData boardData, GameSettings gameSettings)
        {
            _view = new BoardCreationView(poolService, boardData);
            _model = boardModel;

            _boardFitter = new BoardFitter(gameSettings);
        }

        public void Initialize()
        {
            _view.OnCellCreated += _model.AddCell;
        }

        public void Dispose()
        {
            _view.OnCellCreated -= _model.AddCell;
        }
        
        public void Create()
        {
            _view.CreateBoard();
            _boardFitter.AlignCamera(_model.Board);
        }
    }
}
